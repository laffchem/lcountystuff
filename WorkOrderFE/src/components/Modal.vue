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
                <label for="problem">Email:</label>
                <input type="email" class="form-control" v-model="newWorkOrder.email" required>
              </div>              <div class="form-group">
                <label for="problem">Contact Name:</label>
                <input type="text" class="form-control" v-model="newWorkOrder.contactName" required>
              </div>              
              <div class="form-group">
                <label for="problem">Contact Number:</label>
                <input type="tel" class="form-control" v-model="newWorkOrder.contactNumber" required>
              </div>
              <div class="form-group">
                <label for="problem">Problem:</label>
                <input type="text" class="form-control" v-model="newWorkOrder.problem" required>
              </div>
              <div class="form-group">
                <label for="technician">Technician:</label>
                <!-- Dropdown for selecting a technician -->
                <select class="form-control" v-model="newWorkOrder.technicianId"  @change="logTechnicianId" required>
                  <option v-for="technician in technicians" :key="technician.technicianId" :value="technician.technicianId">{{ technician.firstName }}</option>
                </select>
              </div>
              <div class="form-group">
                <label for="status">Status:</label>
                <!-- You can set a default status or provide options based on your requirements -->
                <input type="text" class="form-control" v-model="newWorkOrder.status" required>
              </div>
              <button type="submit" data-bs-dismiss="modal" class="btn btn-primary">Create Work Order</button>
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
        email: '',
        contactName: '',
        contactNumber: '',
        problem: '',
        dateReceived: new Date(),
        dateAssigned: new Date(),
        dateComplete: null,
        technicianId: null,
        status: 'Open',
      },
    };
  },
  mounted() {
    console.log('Technicians prop:', this.technicians);
  }, // Add a comma here
  props: ['technicians'],
  methods: {
    logTechnicianId() {
      console.log('Selected Technician ID:', this.newWorkOrder.technicianId);
    },
    validateTechnicianId() {
      const selectedTechnician = this.technicians.find(
        technician => technician.technicianId === this.newWorkOrder.technicianId
      );

      return !!selectedTechnician;
    },    
    fetchWorkOrdersByStatus() {
      this.$axios.get(`/api/workorders/status/${this.newWorkOrder.status}`)
        .then(response => {
          console.log(response)
          this.$emit('workOrdersUpdated', response.data);
        })
        .catch(err => console.error(err));
    },
    submitForm() {
      if (!this.validateTechnicianId()) {
        console.error('Invalid TechnicianId selected.');
        return;
      }
      const payload = this.newWorkOrder;
      this.$axios.post('/api/workorders', payload)
        .then(response => {
          console.log('Work order submitted successfully', response.data);
          this.fetchWorkOrdersByStatus();
        }).catch(err => {
          console.error('Error submitting work order:', err);
        });
    },
  },
};
</script>

  
  <style scoped>
  /* Modal component styles */
  </style>
  