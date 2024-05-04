import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";

function useFetchExpenses() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  const url = "https://localhost:7057/api/Expense";
  // todo remove mocked expenses
  // todo maping form big letters to small letters - api model to frontend model
  // const mockedExpenses = [
  //   {
  //     name: "Groceries",
  //     description: "Weekly grocery shopping",
  //     money: {
  //       amount: 50,
  //       currency: {
  //         code: "USD",
  //       },
  //     },
  //   },
  //   {
  //     name: "Utilities",
  //     description: "Electricity bill",
  //     money: {
  //       amount: 100,
  //       currency: {
  //         code: "USD",
  //       },
  //     },
  //   },
  //   {
  //     name: "Rent",
  //     description: "Monthly rent payment",
  //     money: {
  //       amount: 1200,
  //       currency: {
  //         code: "USD",
  //       },
  //     },
  //   },
  //   // Add more expenses as needed
  // ];
  useEffect(() => {
    try {
      const apiResponse = getAllApiRequest(url);
      setData(apiResponse);
      setError("");
    } catch (err) {
      setData(null);
      setError(err.message);
    }
  }, []);

  return { data, error };
}

export default useFetchExpenses;
