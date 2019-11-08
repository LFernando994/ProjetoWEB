using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using CLRegras;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using reCAPTCHA.MVC;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register       
        [AllowAnonymous]
        public ActionResult Register()
        {
            DropDownList();          
            return View();
        }

        //Cadastra Cliente e FUncionario no banco de dados
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string perfil) //Recebe as informações da tela e valida Captcha
        {
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);

            ApplicationDbContext db = new ApplicationDbContext();
            DropDownList();
            if (response.Success && ModelState.IsValid)
            {
                
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    string url = Request.UrlReferrer.ToString(); //Pega URL do site 
                    RetirarMaskara(model);
                    if (url.Contains("Funcionario")) // Confere se esta na tela de Cadastro de Cliente ou Funcionário
                    {
                        //Funcionário
                        
                        dbFuncionarioController dbFuncionario = new dbFuncionarioController();
                        dbContatoController dbContato = new dbContatoController();
                        Funcionario novoFuncionario = new Funcionario();
                        Contato novoContato = new Contato();

                        novoFuncionario.nome = model.Nome;
                        novoFuncionario.id = user.Id;
                        novoFuncionario.cpf = model.Cpf;
                        novoFuncionario.rg = Convert.ToInt32(model.Rg);
                        novoFuncionario.dataDeNascimento = model.DataDeNascimento;
                        novoFuncionario.grupoSanguineo = model.GrupoSanguineo;
                        novoFuncionario.sexo = model.Sexo;
                        novoFuncionario.formacao = model.Formacao;
                        novoFuncionario.areaDeAtuacao = model.areaDeAtuacao;
                        novoFuncionario.grauDeEscolaridade = model.grauDeEscolaridade;

                        novoContato.idPessoa = user.Id;
                        novoContato.telefone = model.Telefone;
                        novoContato.email = model.Email;
                        novoContato.cep = model.CEP;
                        novoContato.endereco = model.Endereco;
                        novoContato.cidade = model.Cidade;
                        novoContato.bairro = model.Bairro;
                        novoContato.numero = model.Numero;
                        novoContato.uf = model.Uf;

                        dbFuncionario.CreateRegister(novoFuncionario);
                        dbContato.RegistrarBD(novoContato);                       
                        AddPermissaoPerfil(db, "Funcionario", novoContato.email); // add as visualização de Cliente ou Funcionario
                        dbFuncionario.AddPermissaoDeVisualizacao(db, perfil, novoContato.email); //add se pode editar, criar ou excluir de acordo com o perfil escolhido
                        return RedirectToAction("Index", "Home").Mensagem("Funcionário adicionado com sucesso", "Informação");

                    }
                    else
                    {
                        //Cliente

                        dbClienteController dbCliente = new dbClienteController();
                        dbContatoController dbContato = new dbContatoController();
                        Cliente novoCliente = new Cliente();
                        Contato novoContato = new Contato();

                        novoCliente.nome = model.Nome;
                        novoCliente.id = user.Id;
                        novoCliente.cpf = model.Cpf;
                        novoCliente.rg = Convert.ToInt32(model.Rg);
                        novoCliente.dataDeNascimento = model.DataDeNascimento;
                        novoCliente.grupoSanguineo = model.GrupoSanguineo;
                        novoCliente.dataDeExpiracao = model.DataDeExpiracao;
                        novoCliente.sexo = model.Sexo;

                        novoContato.idPessoa = user.Id;
                        novoContato.telefone = model.Telefone;
                        novoContato.email = model.Email;
                        novoContato.cep = model.CEP;
                        novoContato.endereco = model.Endereco;
                        novoContato.cidade = model.Cidade;
                        novoContato.bairro = model.Bairro;
                        novoContato.numero = model.Numero;
                        novoContato.uf = model.Uf;

                        dbCliente.CreateRegister(novoCliente);
                        dbContato.RegistrarBD(novoContato);
                        AddPermissaoPerfil(db, "Cliente", novoContato.email); // add as visualização de Cliente ou Funcionario


                        return RedirectToAction("Index", "Home").Mensagem("Cliente adicionado com sucesso", "Informação");

                    }
                   
                }
                AddErrors(result);
            }
            else
            {
                ViewBag.ErroCaptcha = "Verifique o Google reCaptcha !";
                return View();
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Método para retirar maskara
        /// </summary>
        /// <param name="model"></param>
        public void RetirarMaskara(RegisterViewModel model)
        {
            var aux = model.Cpf.Replace(".", string.Empty);
            var CPFsemMask = aux.Replace("-", string.Empty);
            var CEPsemMask = model.CEP.Replace("-", string.Empty);

            var aux2 = model.Telefone.Replace("-",string.Empty);
            var aux3 = aux2.Replace("(", string.Empty);
            var TELEFONEsemMask = aux3.Replace(")", string.Empty);

            model.Cpf = CPFsemMask;
            model.CEP = CEPsemMask;
            model.Telefone = TELEFONEsemMask;
        }

        /// <summary>
        /// Metodo para verificar reCaptcha se esta valido
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());

        }

        /// <summary>
        /// Cadastra com o perfil da pessoa (Cliente / Funcionario)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="perfil"></param>
        /// <param name="email"></param>
        private void AddPermissaoPerfil(ApplicationDbContext db, string perfil, string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(email);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if(perfil.Equals("Funcionario"))
            {
                userManager.AddToRole(user.Id, "Funcionario");
            }
            else userManager.AddToRole(user.Id, "Cliente");
           
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        /// <summary>
        /// Preenche as DropList na View mandando para ViewBag
        /// </summary>
        public void DropDownList()
        {
            List<string> sexo = new List<string>();
            List<string> grupoSanguineio = new List<string>();

            sexo.Add("M");
            sexo.Add("F");

            grupoSanguineio.Add("A+");
            grupoSanguineio.Add("A-");
            grupoSanguineio.Add("B+");
            grupoSanguineio.Add("B-");
            grupoSanguineio.Add("AB+");
            grupoSanguineio.Add("AB-");
            grupoSanguineio.Add("O+");
            grupoSanguineio.Add("O-");

            ViewBag.grupoSanguineio = new SelectList(grupoSanguineio);
            ViewBag.sexo = new SelectList(sexo);
        }

        #endregion
    }
}