import { getToken } from "../General/tokenService";

export async function deleteApiRequest(url) {
  const response = await fetch(url, { method: "DELETE" });
  const deleteResponse = await response.json();
  return deleteResponse;
}

export async function deleteAuthorizedApiRequest(url) {
  const response = await fetch(url, {
    method: "DELETE",
    headers: {
      Authorization: `Bearer ${getToken()}`,
    },
  });
  const deleteResponse = await response.json();
  return deleteResponse;
}
