using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebStore.Services
{
	public class CustomAuthStateProvider : AuthenticationStateProvider
	{
		private readonly TokenProvider _tokenProvider;
		private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

		public CustomAuthStateProvider(TokenProvider tokenProvider)
		{
			_tokenProvider = tokenProvider;
		}

		public void Notify()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}

		public async Task SetToken(string token)
		{
			_tokenProvider.Token = token;
			Notify();
			await Task.CompletedTask;
		}

		public async Task Logout()
		{
			_tokenProvider.Token = null;
			Notify();
			await Task.CompletedTask;
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			if (string.IsNullOrWhiteSpace(_tokenProvider.Token))
			{
				return Task.FromResult(new AuthenticationState(_anonymous));
			}

			var jwt = new JwtSecurityTokenHandler().ReadJwtToken(_tokenProvider.Token);

			if (jwt.ValidTo < DateTime.UtcNow)
			{
				_tokenProvider.Token = null;
				return Task.FromResult(new AuthenticationState(_anonymous));
			}

			var identity = new ClaimsIdentity(jwt.Claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);
			var user = new ClaimsPrincipal(identity);

			return Task.FromResult(new AuthenticationState(user));
		}
	}
}
