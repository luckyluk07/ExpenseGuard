import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchIncomes() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(apiUrls.getIncomes);
        const mappedData = apiResponse.incomes.map((element) => ({
          name: element.name,
          category: element.category.name,
          receivedDate: element.receivedDate,
          amount: element.money.amount,
          currency: element.money.currency.code,
        }));
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

export default useFetchIncomes;
