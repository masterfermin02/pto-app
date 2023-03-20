<script setup>
import PtoEditForm  from "../components/ptos/PtoEditForm.vue";

</script>

<template>
  <h1 class="text-2xl font-bold">Edit paid time off</h1>
  <div class="mt-6">
    <suspense>
      <PtoEditForm :id="$route.params.id" />
    </suspense>
  </div>
</template>
