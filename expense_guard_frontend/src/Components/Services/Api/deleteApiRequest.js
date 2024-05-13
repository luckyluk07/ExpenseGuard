async function deleteApiRequest(url) {
  const response = await fetch(url, { method: "DELETE" });
  const deleteResponse = await response.json();
  return deleteResponse;
}
export default deleteApiRequest;
