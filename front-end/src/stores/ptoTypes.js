import { defineStore } from 'pinia'
import { getPtoTypes } from '../services/ptoTypeService'

export const usePtoTypes = defineStore('ptoTypes', {
    state: () => ({
        /** @type {{ description: string, id: number }[]} */
        types: [],
    }),
    getters: {

    },
    actions: {
        async fetchPtoTypes() {
            this.types = [];
            const types = await getPtoTypes()

            types.forEach(type => {
                this.types.push(type)
            })
        }
    },
})
