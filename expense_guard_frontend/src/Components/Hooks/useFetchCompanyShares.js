import { useState, useEffect } from "react";
// import getAllApiRequest from "../Services/Api/GetAllApiRequest";

function useFetchCompanyShares() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  // const url = "/123112/1212";
  // todo remove mocked expenses
  // todo maping form big letters to small letters - api model to frontend model
  const mockedData = [
    {
      name: "ABC Company",
      amount: 200,
      money: {
        amount: 1500,
        currency: { code: "USD" },
      },
      dateOfPurchase: "2023-05-10",
    },
    {
      name: "XYZ Corporation",
      amount: 15,
      money: {
        amount: 2200,
        currency: { code: "EUR" },
      },
      dateOfPurchase: "2024-01-20",
    },
    {
      name: "DEF Enterprises",
      amount: 27,
      money: {
        amount: 1800,
        currency: { code: "GBP" },
      },
      dateOfPurchase: "2022-11-15",
    },
  ];
  // Add more company shares as needed
  useEffect(() => {
    try {
      // const data = getAllApiRequest(url);
      setData(mockedData);
      setError("");
    } catch (err) {
      setData(null);
      setError(err.message);
    }
  }, []);

  return { data, error };
}

export default useFetchCompanyShares;
