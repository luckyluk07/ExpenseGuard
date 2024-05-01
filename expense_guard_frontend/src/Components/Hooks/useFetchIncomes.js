import { useState, useEffect } from "react";
// import getAllApiRequest from "../Services/Api/GetAllApiRequest";

function useFetchIncomes() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  // const url = "/123112/1212";
  // todo remove mocked incomes
  // todo maping form big letters to small letters - api model to frontend model
  const mockedIncomes = [
    {
      name: "Salary",
      category: "Income",
      money: 3000,
      receivedDate: "2024-04-01",
    },
    {
      name: "Freelance",
      category: "Income",
      money: 1500,
      receivedDate: "2024-04-15",
    },
    {
      name: "Bonus",
      category: "Extra Income",
      money: 500,
      receivedDate: "2024-04-25",
    },
  ];
  useEffect(() => {
    try {
      // const data = getAllApiRequest(url);
      setData(mockedIncomes);
      setError("");
    } catch (err) {
      setData(null);
      setError(err.message);
    }
  }, []);
  return { data, error };
}

export default useFetchIncomes;
