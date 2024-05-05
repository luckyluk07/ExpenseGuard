import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchExpenses() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(apiUrls.getExpenses);
        const mappedData = apiResponse.expenses
          ? apiResponse.expenses.map((element) => ({
              name: element.name,
              category: element.category,
              money: element.money,
              spendDate: element.spendDate,
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

export default useFetchExpenses;
