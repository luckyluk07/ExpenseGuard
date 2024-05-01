import { useState, useEffect } from "react";
// import getAllApiRequest from "../Services/Api/GetAllApiRequest";

function useFetchInvestments() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  // const url = "/123112/1212";
  // todo remove mocked incomes
  // todo maping form big letters to small letters - api model to frontend model
  const mockedInvestments = [
    {
      name: "Investment 1",
      startDate: "2023-01-01",
      endDate: "2023-12-31",
      startMoney: {
        amount: 10000,
        currency: "USD",
      },
      interestRate: 5,
      yearCapitalizationAmount: 500,
    },
    {
      name: "Investment 2",
      startDate: "2022-06-15",
      endDate: "2024-06-15",
      startMoney: {
        amount: 15000,
        currency: "EUR",
      },
      interestRate: 7,
      yearCapitalizationAmount: 750,
    },
  ];
  useEffect(() => {
    try {
      // const data = getAllApiRequest(url);
      setData(mockedInvestments);
      setError("");
    } catch (err) {
      setData(null);
      setError(err.message);
    }
  }, []);
  return { data, error };
}

export default useFetchInvestments;
