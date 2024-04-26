import "./App.css";
import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import NavBar from "./Components/Common/NavBar/NavBar";
import ComponentsPreview from "./Pages/ComponentsPreview";
import Expenses from "./Pages/Expenses";
import Incomes from "./Pages/Incomes";
import Home from "./Pages/Home";
import NotFound from "./Pages/NotFound";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavBar
          links={[
            { name: "Incomes", url: "/Incomes" },
            { name: "Expenses", url: "/Expenses" },
            { name: "ComponentsPreview", url: "/ComponentsPreview" },
          ]}
        />
        <main>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="ComponentsPreview" element={<ComponentsPreview />} />
            <Route path="Expenses" element={<Expenses />} />
            <Route path="Incomes" element={<Incomes />} />

            <Route path="*" element={<NotFound />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
