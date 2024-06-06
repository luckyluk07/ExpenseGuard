import { getToken } from "../General/tokenService";

export async function postApiRequest(url, data) {
  try {
    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });

    console.log("Response2", response);
    if (!response.ok) {
      throw new Error("Failed to make POST request");
    }

    const responseData = await response.json();
    console.log("ResponseData", responseData);
    return responseData;
  } catch (error) {
    throw new Error(`Error making POST request: ${error.message}`);
  }
}

export async function postAuthorizedApiRequest(url, data) {
  try {
    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getToken()}`,
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      throw new Error("Failed to make POST request");
    }

    const responseData = await response.json();
    return responseData;
  } catch (error) {
    throw new Error(`Error making POST request: ${error.message}`);
  }
}
