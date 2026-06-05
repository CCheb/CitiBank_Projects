import { useState } from "react";
import Navbar from "../components/navBar";
import { deleteCustomer } from "../services/bankApi";

function CustomerDeletePage() {
    const [customerId, setCustomerId] = useState("");
    const [message, setMessage] = useState("");

    async function handleDelete() {
        try {
            const deletedCustomer =
                await deleteCustomer(customerId);

            setMessage(
                `Deleted customer: ${deletedCustomer.name}`
            );

            setCustomerId("");
        }
        catch {
            setMessage("Customer not found");
        }
    }

    return (
        <>
            <Navbar />

            <div className="container">
                <h1>Delete Customer</h1>

                <input
                    type="number"
                    value={customerId}
                    onChange={(e) =>
                        setCustomerId(e.target.value)
                    }
                    placeholder="Customer ID"
                />

                <button onClick={handleDelete}>
                    Delete Customer
                </button>

                {message && (
                    <p>{message}</p>
                )}
            </div>
        </>
    );
}

export default CustomerDeletePage;