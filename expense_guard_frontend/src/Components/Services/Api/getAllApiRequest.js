async function getAllApiRequest(url) {
  const response = await fetch(url);
  const collection = await response.json();
  return collection;
}
export default getAllApiRequest;
