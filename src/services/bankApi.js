const API_URL = "http://localhost:5203/api";

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