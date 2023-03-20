<script>
import PaidTimeOffTable from '../components/ptos/PaidTimeOffTable.vue';
import router from "../router/index.js";
export default {
  components: {
    PaidTimeOffTable
  },
  methods: {
    addNewPto() {
      router.push({ name: 'AddPto' });
    }
  }
}
</script>

<template>
  <h1 class="text-2xl font-bold">Paid Time Off</h1>
  <div class="flex justify-end">
    <button @click="addNewPto" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
      Add New PTO
    </button>
  </div>
  <div class="mt-6">
    <suspense>
      <PaidTimeOffTable />
    </suspense>
  </div>
</template>
