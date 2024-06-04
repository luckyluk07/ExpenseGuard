import { getToken } from "../General/tokenService";

export async function getAllApiRequest(url) {
  const response = await fetch(url);
  const collection = await response.json();
  return collection;
}

export async function getAllAuthorizedApiRequest(url) {
  const response = await fetch(url, {
    method: "GET",
    headers: {
      Authorization: `Bearer ${getToken()}`,
    },
  });
  const collection = await response.json();
  return collection;
}
