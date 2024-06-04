const AUTHORIZATION_KEY = "authorizationToken";

export function setToken(token) {
  localStorage.setItem(AUTHORIZATION_KEY, token);
}

export function getToken() {
  return localStorage.getItem(AUTHORIZATION_KEY);
}

export function removeToken() {
  localStorage.removeItem(AUTHORIZATION_KEY);
}
