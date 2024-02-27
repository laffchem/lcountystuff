<!-- Modal.vue -->
<template>
    <div class="modal fade" id="submitModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create Work Order</h5>
            <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- Content for creating a work order -->
            <form @submit.prevent="submitForm">
              <div class="form-group">
                <label for="problem">Problem:</label>
                <input type="text" class="form-control" v-model="newWorkOrder.problem" required>
              </div>
              <div class="form-group">
                <label for="technician">Technician:</label>
                <!-- Dropdown for selecting a technician -->
                <select class="form-control" v-model="newWorkOrder.technicianId" required>
                  <option v-for="technician in technicians" :key="technician.id" :value="technician.id">{{ technician.firstName }}</option>
                </select>
              </div>
              <div class="form-group">
                <label for="status">Status:</label>
                <!-- You can set a default status or provide options based on your requirements -->
                <input type="text" class="form-control" v-model="newWorkOrder.status" required>
              </div>
              <button type="submit" class="btn btn-primary">Create Work Order</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        newWorkOrder: {
          problem: '',
          technicianId: null,
          status: '',
          technicians: []
        },
      };
    },
    props: ['technicians'], // Pass the list of technicians as a prop
    methods: {
      submitForm() {
          this.newWorkOrder = {
          problem: '',
          technicianId: null,
          status: '',
        };
      },
    },
  };
  </script>
  
  <style scoped>
  /* Modal component styles */
  </style>
  