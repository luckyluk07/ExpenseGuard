async function updateApiRequest(url) {
  const response = await fetch(url, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
  });
  const deleteResponse = await response.json();
  return deleteResponse;
}
export default updateApiRequest;
