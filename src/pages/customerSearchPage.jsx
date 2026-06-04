import { useState } from "react";
import Navbar from "../components/Navbar";
import { getCustomerById } from "../services/bankApi";

function CustomerSearchPage() {
    const [searchId, setSearchId] = useState("");
    const [customer, setCustomer] = useState(null);
    const [error, setError] = useState("");

    async function handleSearch() {
        try {
            const result = await getCustomerById(searchId);

            setCustomer(result);
            setError("");
        } catch {
            setCustomer(null);
            setError("Customer not found");
        }
    }

    return (
        <>
            <Navbar />

            <div className="container">
                <h1>Search Customer</h1>

                <input
                    type="number"
                    value={searchId}
                    onChange={(e) => setSearchId(e.target.value)}
                    placeholder="Enter Customer ID"
                />

                <button onClick={handleSearch}>
                    Search
                </button>

                {error && (
                    <p style={{ color: "red" }}>{error}</p>
                )}

                {customer && (
                    <div className="card">
                        <h2>{customer.name}</h2>

                        <p><strong>ID:</strong> {customer.id}</p>
                        <p><strong>Email:</strong> {customer.email}</p>

                        <h3>Accounts</h3>

                        {customer.accounts && customer.accounts.length > 0 ? (
                            customer.accounts.map((account) => (
                                <div key={account.id} className="card">
                                    <p>
                                        <strong>Account Number:</strong>{" "}
                                        {account.accountNumber}
                                    </p>

                                    <p>
                                        <strong>Balance:</strong> ${account.balance}
                                        
                                    </p>
                                </div>
                            ))
                        ) : (
                            <p>No accounts found</p>
                        )}
                    </div>
                )}
            </div>
        </>
    );
}

export default CustomerSearchPage;