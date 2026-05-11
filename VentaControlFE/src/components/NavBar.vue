<template>
  <nav class="navbar navbar-expand-lg navbar-dark custom-navbar shadow-lg">
    <div class="container-fluid px-4">

      <!-- Logo -->
      <RouterLink to="/home" class="navbar-brand fw-bold fs-2 d-flex align-items-center">
        <i class="bi bi-shop me-2"></i>
        Venta Control
      </RouterLink>

      <!-- Botón móvil -->
      <button
        class="navbar-toggler border-0"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <!-- Links -->
      <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
        <ul class="navbar-nav gap-3">

          <li class="nav-item">
            <RouterLink to="/home" class="nav-link custom-link">
              <i class="bi bi-house-door-fill me-1"></i>
              Home
            </RouterLink>
          </li>

          <li class="nav-item">
            <RouterLink to="/registro" class="nav-link custom-link">
              <i class="bi bi-person-plus-fill me-1"></i>
              Registro
            </RouterLink>
          </li>

          <li class="nav-item">
            <RouterLink to="/login" class="nav-link custom-link">
              <i class="bi bi-box-arrow-in-right me-1"></i>
              Login
            </RouterLink>
          </li>

        </ul>
      </div>

    </div>
  </nav>
</template>

<script setup lang="ts">
</script>

<style scoped>
.custom-navbar {
  background: linear-gradient(90deg, #0f172a, #1e293b);
  padding-top: 18px;
  padding-bottom: 18px;
}

.navbar-brand {
  color: white !important;
  letter-spacing: 1px;
}

.custom-link {
  color: #e2e8f0 !important;
  font-size: 1.1rem;
  font-weight: 500;
  padding: 10px 18px !important;
  border-radius: 10px;
  transition: all 0.3s ease;
}

.custom-link:hover {
  background-color: rgba(255, 255, 255, 0.12);
  color: white !important;
  transform: translateY(-2px);
}

.custom-link.router-link-active {
  background-color: #2563eb;
  color: white !important;
}
</style>
<script setup lang="ts">
</script>