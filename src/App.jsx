import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "./pages/homePage";
import CustomersPage from "./pages/customersPage";
import CustomerSearchPage from "./pages/customerSearchPage";


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/customers" element={<CustomersPage />} />
        <Route path="/customers/search" element={<CustomerSearchPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;