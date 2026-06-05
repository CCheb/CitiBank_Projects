import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "./pages/homePage";
import CustomersPage from "./pages/customersPage";
import CustomerSearchPage from "./pages/customerSearchPage";
import CustomerCreatePage from "./pages/customerCreatePage";


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/customers" element={<CustomersPage />} />
        <Route path="/customers/search" element={<CustomerSearchPage />} />
        <Route path="/customers/create" element={<CustomerCreatePage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;