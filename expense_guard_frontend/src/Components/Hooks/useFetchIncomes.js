import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";

function useFetchIncomes() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  const url = "https://localhost:7057/api/Income";
  // todo remove mocked incomes
  // todo maping form big letters to small letters - api model to frontend model
  // const mockedIncomes = [
  //   {
  //     name: "Salary",
  //     category: "Income",
  //     money: 3000,
  //     receivedDate: "2024-04-01",
  //   },
  //   {
  //     name: "Freelance",
  //     category: "Income",
  //     money: 1500,
  //     receivedDate: "2024-04-15",
  //   },
  //   {
  //     name: "Bonus",
  //     category: "Extra Income",
  //     money: 500,
  //     receivedDate: "2024-04-25",
  //   },
  // ];
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(url);
        const mappedData = apiResponse.incomes.map((element) => ({
          name: element.name,
          category: element.category.name,
          receivedDate: element.receivedDate,
          amount: element.money.amount,
          currency: element.money.currency.Code,
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
