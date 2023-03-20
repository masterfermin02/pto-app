import {VUE_SERVER_API_URL} from "./index.js";

const endpoint = `${VUE_SERVER_API_URL}/PtoTypes`;
export const getPtoTypes = async () => {
    const response = await fetch(endpoint, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    return await response.json();
}

export const getPtoType = async (id) => {
    const response = await fetch(`${endpoint}/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            accept: 'text/plain'
        }
    });
    return await response.json();
}

export const createPtoType = async (ptoType) => {
    const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(ptoType)
    });
    return await response.json();
}

export const updatePtoType = async (ptoType) => {
    const response = await fetch(`${endpoint}/${ptoType.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(ptoType)
    });
    return await response.json();
}
