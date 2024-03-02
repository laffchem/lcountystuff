<template>
  <div>
    <h1>Work Orders</h1>
     <button @click="fetchTechnicians" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#submitModal">
Create Work Order</button>

     <Modal :technicians="technicians" @workOrdersUpdated="updateWorkOrders"/>
     
    <div class="container mt-5">
      <label class="mr-2">Status:</label>
    <select class="form-select" v-model="status" @change="fetchWorkOrdersByStatus">
      <option value="Open">Open</option>
      <option value="Closed">Closed</option>
    </select>
  </div>
  <div class="container">

    <table class="table">
      <thead>
        <tr>
          <!-- <th>ID</th> -->
          <th>Email</th>
          <th>Contact Name</th>
          <th>Contact Number</th>
          <th>Problem</th>
          <th>Date Received</th>
          <th>Status</th>
          <th>Technician</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in workOrders" :key="order.id">
          <!-- <td>{{ order.id }}</td> -->
          <td>{{ order.email }}</td>
          <td>{{ order.contactName }}</td>
          <td>{{ order.contactNumber }}</td>
          <td>{{ order.problem }}</td>
          <td>{{ order.dateReceived }}</td>
          <td>{{ order.status }}</td>
          <td>{{ order.technician.firstName }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
</template>


<style scoped>
</style>

<script>
import Modal from './components/Modal.vue';
export default {
  props: ['technicians'],
  data() {
    return {
      workOrders: [],
      status: 'Open',
      showModal: false,
      technicians: []
      
    };
  },
  components: {
    Modal,
  },
  mounted() {
    this.fetchWorkOrdersByStatus();
  },
  methods: {
    fetchWorkOrdersByStatus() {
      this.$axios.get(`/api/workorders/status/${this.status}`)
        .then(response => {
          console.log(response)
          this.workOrders = response.data
        })
        .catch(err => console.error(err));
    },
    fetchTechnicians() {
      this.$axios.get('/api/technician')
        .then(response => {
          this.technicians = response.data;
        })
        .catch(error => {
          console.error('Error fetching technicians:', error);
        });
    },
    updateWorkOrders(newWorkOrders) {
      this.workOrders = newWorkOrders;
    },
  },
}
</script>
