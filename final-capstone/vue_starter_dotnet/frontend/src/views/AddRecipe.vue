<template>
  <div class="panel-body">
    <vue-form-generator :schema="schema" :model="model" :options="formOptions"></vue-form-generator>
  </div>
</template>

<script>
  //import VueFormGenerator from "vue-form-generator";

export default {
  data () {
    return {
      model: {
      },
      schema: {
        fields: [
          {
            type: 'input',
            inputType: 'text',
            label: 'Recipe Name',
            model: 'id',
            readonly: true,
            disabled: true
          }
        ]
      },
      formOptions: {
        validateAfterLoad: true,
        validateAfterChanged: true,
        validateAsync: true
      }
    }
  }
}
</script>

<style scoped>

</style>