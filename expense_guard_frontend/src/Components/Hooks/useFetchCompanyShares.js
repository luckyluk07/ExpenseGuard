import { useState, useEffect } from "react";
import getAllApiRequest from "../Services/Api/getAllApiRequest";
import apiUrls from "../../Shared/apiUrls";

function useFetchCompanyShares() {
  const [data, setData] = useState(null);
  const [error, setError] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiResponse = await getAllApiRequest(apiUrls.getCompanyShares);
        console.log(apiResponse.companyShares);
        const mappedData = apiResponse.companyShares
          ? apiResponse.companyShares.map((element) => ({
              name: element.name,
              amount: element.amount,
              money: {
                amount: element.price.amount,
                currency: element.price.currency,
              },
              dateOfPurchase: element.dateOfPurchase,
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

export default useFetchCompanyShares;
