const API_URL = "http://localhost:5203/api";

export async function getCustomers() {
    const response = await fetch(`${API_URL}/customers`);

    if (!response.ok) {
        throw new Error("Failed to fetch customers");
    }

    return await response.json();
}