import { useState, useEffect } from "react";
// import getAllApiRequest from "../Services/Api/GetAllApiRequest";

function useFetchExpenses() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  // const url = "/123112/1212";
  // todo remove mocked expenses
  const mockedExpenses = [
    {
      name: "Groceries",
      description: "Weekly grocery shopping",
      money: {
        amount: 50,
        currency: {
          code: "USD",
        },
      },
    },
    {
      name: "Utilities",
      description: "Electricity bill",
      money: {
        amount: 100,
        currency: {
          code: "USD",
        },
      },
    },
    {
      name: "Rent",
      description: "Monthly rent payment",
      money: {
        amount: 1200,
        currency: {
          code: "USD",
        },
      },
    },
    // Add more expenses as needed
  ];
  useEffect(() => {
    try {
      // const data = getAllApiRequest(url);
      setData(mockedExpenses);
      setError("");
    } catch (err) {
      setData(null);
      setError(err.message);
    }
  }, []);

  return { data, error };
}

export default useFetchExpenses;
