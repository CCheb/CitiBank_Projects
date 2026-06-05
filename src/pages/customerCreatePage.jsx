import { useState } from "react";
import Navbar from "../components/navBar";
import { createCustomer } from "../services/bankApi";

function CustomerCreatePage() {
    const [id, setId] = useState("");
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");

    const [message, setMessage] = useState("");

    async function handleSubmit(event) {
        event.preventDefault();

        const customer = {
            id: Number(id),
            name: name,
            email: email,
            accounts: []
        };

        try {
            const createdCustomer =
                await createCustomer(customer);

            setMessage(
                `Customer ${createdCustomer.name} created successfully`
            );

            setId("");
            setName("");
            setEmail("");
        }
        catch {
            setMessage("Failed to create customer");
        }
    }

    return (
        <>
            <Navbar />

            <div className="container">
                <h1>Create Customer</h1>

                <form onSubmit={handleSubmit}>

                    <div>
                        <label>Customer ID</label>

                        <input
                            type="number"
                            value={id}
                            onChange={(e) =>
                                setId(e.target.value)}
                        />
                    </div>

                    <div>
                        <label>Name</label>

                        <input
                            type="text"
                            value={name}
                            onChange={(e) =>
                                setName(e.target.value)}
                        />
                    </div>

                    <div>
                        <label>Email</label>

                        <input
                            type="email"
                            value={email}
                            onChange={(e) =>
                                setEmail(e.target.value)}
                        />
                    </div>

                    <button type="submit">
                        Create Customer
                    </button>

                </form>

                {message && (
                    <p>{message}</p>
                )}
            </div>
        </>
    );
}

export default CustomerCreatePage;