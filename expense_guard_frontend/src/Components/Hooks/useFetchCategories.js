import { useState, useEffect } from "react";
import { getAllApiRequest } from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchCategories() {
  const [data, setData] = useState([]);
  const [error, setError] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(apiUrls.getCategories);
        const mappedData = apiResponse.categories
          ? apiResponse.categories.map((element) => ({
              id: element.id,
              name: element.name,
              description: element.description,
            }))
          : [];
        setData(mappedData);
        setError("");
      } catch (err) {
        setData(null);
        setError(err.message);
      }
    };

    fetchData();
  }, []);

  return { data, error };
}

export default useFetchCategories;
