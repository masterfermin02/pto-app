import {VUE_SERVER_API_URL} from "./index.js";

const endpoint = `${VUE_SERVER_API_URL}/PaidTimeOff`;
export const createPto = async (pto) => {
    const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            accept: 'application/json'
        },
        body: JSON.stringify(pto)
    });
    return await response.json();
}

export const getPto = async (id) => {
    const response = await fetch(`${endpoint}/${id}`);
    return await response.json();
}

export const getPtos = async () => {
    const response = await fetch(endpoint);
    return await response.json();
}

export const updatePto = async (pto) => {
    const response = await fetch(`${endpoint}/${pto.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pto)
    });
    return { status: response.status };
}

export const deletePto = async (id) => {
    const response = await fetch(`${endpoint}/${id}`, {
        method: 'DELETE'
    });
    return { status: response.status };
}
