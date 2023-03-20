<script setup>
import { computed } from 'vue'
import { usePtoStore } from '../../stores/index'
import {onMounted} from "vue";
import router from "../../router/index.js";

const ptoStore = usePtoStore();

const ptos = computed(() => ptoStore.$state.ptos);

onMounted(async () => {
  await ptoStore.fetchAll();
});

const editPto = (pto) => {
  router.push({ path: '/edit-pto/' + pto.id });
}

const deletePto = async (pto) => {
  var result = confirm("Are you sure you want to delete this PTO: " + pto.firstName + " " + pto.lastName + "?");
  if (result) {
    await ptoStore.delete(pto.id);
    await ptoStore.fetchAll();
  }
}

</script>
<template>
    <div class="w-full mb-8 overflow-hidden rounded-lg shadow-xs">
            <div class="w-full overflow-x-auto">
                <table class="w-full whitespace-no-wrap">
                  <thead>
                    <tr
                      class="text-xs font-semibold tracking-wide text-left text-gray-500 uppercase border-b dark:border-gray-700 bg-gray-50 dark:text-gray-400 dark:bg-gray-800"
                    >
                      <th class="px-4 py-3">First Name</th>
                      <th class="px-4 py-3">Last Name</th>
                      <th class="px-4 py-3">Type</th>
                      <th class="px-4 py-3">Date</th>
                      <th class="px-4 py-3">Actions</th>
                    </tr>
                  </thead>
                  <tbody
                    class="bg-white divide-y dark:divide-gray-700 dark:bg-gray-800"
                  >
                    <tr v-for="pto in ptos" :key="pto.id">
                      <td class=" text-white">{{ pto.firstName }}</td>
                      <td class=" text-white">{{ pto.lastName }}</td>
                      <td class="text-white">{{ pto.ptoType.description }}</td>
                      <td class=" text-white">{{ pto.ptoDate }}</td>
                      <td >
                        <button @click="editPto(pto)" class="bg-blue-500 mr-4 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                          Edit
                        </button>
                        <button @click="deletePto(pto)" class="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded">
                          Delete
                        </button>
                      </td>
                    </tr>
                  </tbody>
                </table>
            </div>
    </div>
</template>
