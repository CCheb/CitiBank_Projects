const API_URL = "https://citibank-projects.onrender.com/api";

export async function getCustomers() {
    const response = await fetch(`${API_URL}/customers`);

    if (!response.ok) {
        throw new Error("Failed to fetch customers");
    }

    return await response.json();
}

export async function getCustomerById(id) {
    const response = await fetch(`${API_URL}/customers/${id}`);

    if (!response.ok) {
        throw new Error("Customer not found");
    }

    return await response.json();
}

export async function createCustomer(customer) {
    const response = await fetch(
        `${API_URL}/customers`,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(customer)
        }
    );

    if (!response.ok) {
        throw new Error("Failed to create customer");
    }

    return await response.json();
}

export async function deleteCustomer(id) {
    const response = await fetch(
        `${API_URL}/customers/${id}`,
        {
            method: "DELETE"
        }
    );

    if (!response.ok) {
        throw new Error("Customer not found");
    }

    return await response.json();
}