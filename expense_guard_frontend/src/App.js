import "./App.css";
import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import paths from "./Shared/routes";
import NavBar from "./Components/Common/NavBar/NavBar";
import Expenses from "./Pages/Expenses";
import Incomes from "./Pages/Incomes";
import Home from "./Pages/Home";
import NotFound from "./Pages/NotFound";
import Profile from "./Pages/Profile";
import News from "./Pages/News";
import Investments from "./Pages/Investments";
import CompanyShares from "./Pages/CompanyShares";
import ErrorPage from "./Pages/ErrorPage";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavBar
          links={[
            { name: "Profile", url: paths.profile },
            { name: "Incomes", url: paths.incomes },
            { name: "Expenses", url: paths.expenses },
            { name: "Investments", url: paths.investments },
            { name: "Company Shares", url: paths.companyShares },
            { name: "News", url: paths.news },
          ]}
        />
        <main>
          <Routes>
            <Route path={paths.home} element={<Home />} />
            <Route path={paths.expenses} element={<Expenses />} />
            <Route path={paths.incomes} element={<Incomes />} />
            <Route path={paths.profile} element={<Profile />} />
            <Route path={paths.news} element={<News />} />
            <Route path={paths.investments} element={<Investments />} />
            <Route path={paths.companyShares} element={<CompanyShares />} />
            <Route path={paths.error} element={<ErrorPage />} />

            <Route path={paths.notFound} element={<NotFound />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
