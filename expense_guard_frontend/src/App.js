import "./App.css";
import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import NavBar from "./Components/Common/NavBar/NavBar";
import ComponentsPreview from "./Pages/ComponentsPreview";
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
            { name: "Profile", url: "/Profile" },
            { name: "Incomes", url: "/Incomes" },
            { name: "Expenses", url: "/Expenses" },
            { name: "Investments", url: "/Investments" },
            { name: "Company Shares", url: "/CompanyShares" },
            { name: "News", url: "/News" },
            { name: "Components Preview", url: "/ComponentsPreview" },
          ]}
        />
        <main>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="ComponentsPreview" element={<ComponentsPreview />} />
            <Route path="Expenses" element={<Expenses />} />
            <Route path="Incomes" element={<Incomes />} />
            <Route path="Profile" element={<Profile />} />
            <Route path="News" element={<News />} />
            <Route path="Investments" element={<Investments />} />
            <Route path="CompanyShares" element={<CompanyShares />} />
            <Route path="Error" element={<ErrorPage />} />

            <Route path="*" element={<NotFound />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
