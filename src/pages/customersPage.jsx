import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import { getCustomers } from "../services/bankApi";

function CustomersPage() {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        async function loadCustomers() {
            try {
                const data = await getCustomers();
                setCustomers(data);
            } catch (error) {
                console.error(error);
            }
        }

        loadCustomers();
    }, []);

    return (
        <>
            <Navbar />

            <div className="container">
                <h1>Customers</h1>

                <ul>
                    {customers.map(customer => (
                        <li key={customer.id}>
                            {customer.name}
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
}

export default CustomersPage;