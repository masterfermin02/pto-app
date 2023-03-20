<script setup>
import PtoCreateForm  from "../components/ptos/PtoCreateForm.vue";
</script>

<template>
  <h1 class="text-2xl font-bold">Add paid time off</h1>
  <div class="mt-6">
    <suspense>
      <PtoCreateForm />
    </suspense>
  </div>
</template>
