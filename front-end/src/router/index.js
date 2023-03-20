import { createRouter, createWebHistory } from 'vue-router'
import PtoPage from '../pages/PtoPage.vue'
import AddPto from '../pages/AddPto.vue'
import EditPto from '../pages/EditPto.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Pto',
      component: PtoPage
    },
    {
      path: '/add-pto',
      name: 'AddPto',
      component: AddPto
    },
    {
        path: '/edit-pto/:id',
        name: 'EditPto',
        component: EditPto
    }
  ]
})

export default router
