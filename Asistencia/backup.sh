#\!/bin/bash
# Script para respaldar la base de datos MySQL que corre en Docker
# Uso: bash backup.sh
MYSQL_CONTAINER="mysql_asistencia"
DB_NAME="asistencia_db"
DB_ROOT_PASS="safe"
LOCAL_BACKUP_DIR="./backups"

TIMESTAMP=$(date +"%Y%m%d_%H%M%S")
BACKUP_FILE="backup_${DB_NAME}_${TIMESTAMP}.sql"

echo "=== Respaldo de Base de Datos ==="
echo "Fecha: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

mkdir -p "$LOCAL_BACKUP_DIR"

echo "[1/1] Creando respaldo desde el contenedor '$MYSQL_CONTAINER'..."
docker exec "$MYSQL_CONTAINER" mysqldump -u root -p"$DB_ROOT_PASS" "$DB_NAME" > "$LOCAL_BACKUP_DIR/$BACKUP_FILE"

if [ $? -ne 0 ]; then
  echo "ERROR: Falló la creación del respaldo"
  rm -f "$LOCAL_BACKUP_DIR/$BACKUP_FILE"
  exit 1
fi

echo ""
echo "=== Respaldo completado ==="
echo "Archivo: $LOCAL_BACKUP_DIR/$BACKUP_FILE"
echo "Tamaño:  $(ls -lh "$LOCAL_BACKUP_DIR/$BACKUP_FILE" | awk '{print $5}')"
echo ""
echo "Para restaurar:"
echo "  docker exec -i $MYSQL_CONTAINER mysql -u root -p$DB_ROOT_PASS $DB_NAME < $LOCAL_BACKUP_DIR/$BACKUP_FILE"
