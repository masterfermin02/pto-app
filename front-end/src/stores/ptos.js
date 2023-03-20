import { defineStore } from 'pinia'
import { createPto, getPtos, getPto, updatePto, deletePto } from '../services/ptoService'

export const usePtoStore = defineStore('ptos', {
    state: () => ({
        /** @type {{ id: number, firstName: string, lastName: string, type: int, date: date }[]} */
        ptos: [],
    }),
    getters: {

    },
    actions: {
        async save(pto) {
            return await createPto(pto)
        },
        async fetchAll() {
            this.ptos = [];
            const ptos = await getPtos()

            ptos.forEach(pto => {
                this.ptos.push(pto)
            })
        },
        async fetchPtoById(id) {
            return await getPto(id)
        },
        async update(pto) {
            return await updatePto(pto)
        },
        async delete(id) {
            return await deletePto(id)
        }
    },
})
