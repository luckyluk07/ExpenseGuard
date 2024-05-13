import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchInvestments() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  const url = apiUrls.getInvestmentsDeposits;
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(url);
        const mappedData = apiResponse.investmentDeposits
          ? apiResponse.investmentDeposits.map((element) => ({
              id: element.id,
              name: element.name,
              startDate: element.startDate,
              endDate: element.endDate,
              startMoney: {
                amount: element.startMoney.amount,
                currency: element.startMoney.currency.code,
              },
              interestRate: element.interestRate,
              yearCapitalizationAmount: element.yearCapitalizationAmount,
            }))
          : [];
        console.log(mappedData);
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

export default useFetchInvestments;
