async function updateApiRequest(url, body) {
  const response = await fetch(url, {
    method: "PUT",
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json",
    },
  });
  const deleteResponse = await response.json();
  return deleteResponse;
}
export default updateApiRequest;
