import { useState, useEffect } from "react";
import { getAllApiRequest } from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchCurrencies() {
  const [data, setData] = useState([]);
  const [error, setError] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(apiUrls.getCurrencies);
        const mappedData = apiResponse.currencies
          ? apiResponse.currencies.map((element) => ({
              id: element.id,
              name: element.name,
              code: element.code,
              country: element.country,
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

export default useFetchCurrencies;
