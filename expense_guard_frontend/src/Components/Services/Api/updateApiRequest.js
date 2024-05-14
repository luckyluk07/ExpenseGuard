async function updateApiRequest(url) {
  const response = await fetch(url, { method: "PUT" });
  const deleteResponse = await response.json();
  return deleteResponse;
}
export default updateApiRequest;
