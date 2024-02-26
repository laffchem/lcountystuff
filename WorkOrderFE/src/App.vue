<template>
  <div>
    <h1>Work Orders</h1>

    <label>Status: </label>
    <select v-model="status" @change="fetchWorkOrdersByStatus">
      <option value="Open">Open</option>
      <option value="Closed">Closed</option>
      <!-- Add other status options -->
    </select>
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Email</th>
          <th>Contact Name</th>
          <th>Problem</th>
          <th>Date Received</th>
          <th>Status</th>
          <th>Technician</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in workOrders" :key="order.id">
          <td>{{ order.id }}</td>
          <td>{{ order.email }}</td>
          <td>{{ order.contactName }}</td>
          <td>{{ order.problem }}</td>
          <td>{{ order.dateReceived }}</td>
          <td>{{ order.status }}</td>
          <td>{{ order.technician.name }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>


<style scoped>
</style>

<script>
export default {
  data() {
    return {
      workOrders: [],
      status: 'Open',
    };
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
    }
  }
}</script>
