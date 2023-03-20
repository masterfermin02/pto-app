<script setup>

import {onMounted, ref, computed, reactive} from "vue";
import {usePtoTypes, usePtoStore} from "../../stores";
import router from "../../router/index.js";

const ptoTypes = usePtoTypes();
const ptoStore = usePtoStore();
const pto = reactive({
  ptoType: {},
  ptoDate: '',
  ptoHours: ''
});

const errors = reactive({});

const processing = ref(false);

const types = computed(() => ptoTypes.$state.types);
const ptoDateTime = computed(() => pto.ptoDate + ' ' + pto.ptoHours);

const props = defineProps({
  id: {
    type: Number,
    required: true
  }
});
const editPto = async () => {
  if (!processing.value && checkForm()) {
    processing.value = true;
    try {
      await ptoStore.update({
        id: props.id,
        firstName: pto.firstName,
        lastName: pto.lastName,
        type:  pto.ptoType.id,
        ptoDate: new Date(ptoDateTime.value).toISOString(),
      });
      router.push({ path: '/' });
    } catch (e) {
      console.log(e);
    } finally {
      processing.value = false;
    }
  }
};
const checkForm = () => {
  errors.firstName = null;
  errors.lastName = null;
  errors.ptoType = null;
  errors.ptoDate = null;
  errors.ptoHours = null;

  if (!pto.firstName) {
    errors.firstName = "First name is required.";
  }
  if (!pto.lastName) {
    errors.lastName = "Last name is required.";
  }
  if (!pto.ptoType) {
    errors.ptoType = "PTO type is required.";
  }
  if (!pto.ptoDate) {
    errors.ptoDate = "PTO date is required.";
  }
  if (!pto.ptoHours) {
    errors.ptoHours = "PTO hours is required.";
  }

  return Object.keys(errors).filter(error => errors[error]).length === 0;
};

onMounted(async () => {
  await ptoTypes.fetchPtoTypes();
  const result = await ptoStore.fetchPtoById(props.id);
  pto.firstName = result.firstName;
  pto.lastName = result.lastName;
  pto.ptoType = types.value.find(type => type.id === result.type);
  pto.ptoDate = result.ptoDate.split('T')[0];
  pto.ptoHours = result.ptoDate.split('T')[1].split(':')[0] + ':' + result.ptoDate.split('T')[1].split(':')[1];
});


</script>

<template>
  <div >
    <form>
      <div class="mb-4">
        <label class="block text-left pl-2 text-gray-700 text-sm font-bold mb-2" for="firstName">
          First Name:*
        </label>
        <input
            v-model="pto.firstName"
            :class="errors.firstName ? 'border-red-500' : ''"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="firstName" type="text" placeholder="Juan">
      </div>
      <div class="mb-4">
        <label class="block text-left pl-2 text-gray-700 text-sm font-bold mb-2" for="lastName">
          Last Name:*
        </label>
        <input v-model="pto.lastName"
               :class="errors.lastName ? 'border-red-500' : ''"
               class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="lastName" type="text" placeholder="Dela Cruz">
      </div>
      <div class="mb-4">
        <label class="block text-left pl-2 text-gray-700 text-sm font-bold mb-2" for="ptoType">
          PTO Type:*
        </label>
        <select v-model="pto.ptoType"
                :class="errors.ptoType ? 'border-red-500' : ''"
                class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="ptoType">
          <option v-for="type in types" :key="type.id" :value="type">{{ type.description }}</option>
        </select>
      </div>
      <div class="mb-4">
        <label class="block text-left pl-2 text-gray-700 text-sm font-bold mb-2" for="ptoDate">
          PTO Date:*
        </label>
        <input v-model="pto.ptoDate"
               :class="errors.ptoDate ? 'border-red-500' : ''"
               class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="ptoDate" type="date" placeholder="PTO Date">
      </div>
      <div class="mb-4">
        <label class="block text-left pl-2 text-gray-700 text-sm font-bold mb-2" for="ptoHours">
          PTO Hours:*
        </label>
        <input v-model="pto.ptoHours"
               :class="errors.ptoHours ? 'border-red-500' : ''"
               class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="ptoHours" type="time" placeholder="PTO Hours">
      </div>
    </form>
  </div>
  <div  class="flex justify-end">
    <button @click="editPto" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
      <span v-show="!processing" >Save</span>
      <span v-show="processing" >Save ...</span>
    </button>
  </div>
</template>
