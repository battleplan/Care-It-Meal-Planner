import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      redirect: { name: 'main' }
    },
/*     {
      path: '/category',
      name: 'category',
      component: Users
    }*/
    {
      path: '/recipe/:id',
      name: 'recipe'
    } 
  ]
})
