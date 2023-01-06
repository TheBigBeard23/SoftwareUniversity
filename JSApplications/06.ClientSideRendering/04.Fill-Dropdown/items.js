export async function getItems() {
    const res = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    return await res.json();
}

