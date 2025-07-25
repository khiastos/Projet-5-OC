namespace Projet_5.Models.Utils
{
    public static class ImageUtils
    {
        public static async Task AddAnImageAsync<T>(
            T entity,
            IFormFile imageFile,
            string imagesFolder,
            Action<T, string> setImageUrl)
            where T : class
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Pointe le chemin de téléchargement ou crée le dossier s'il n'existe pas
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imagesFolder}");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                // Crée un nom de fichier avec un GUID pour éviter les conflits + l'extension du fichier d'origine
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                // Sauvegarde le fichier dans le bon dossier, après l'avoir récupéré via le formulaire utilisateur
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Met à jour l'URL de l'image dans l'entité via le setter
                setImageUrl(entity, $"/images/{imagesFolder}/{fileName}");
            }
        }
        public static async Task UpdateImageAsync<T>(
            T entity,
            IFormFile imageFile,
            string imagesFolder,
            Func<T, string?> getImageUrl,
            Action<T, string> setImageUrl)
            where T : class
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var oldImageUrl = getImageUrl(entity);

                // Supprimer l'ancienne image si elle existe
                if (!string.IsNullOrEmpty(oldImageUrl))
                {
                    var oldPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        // Permet de supprimer l'ancienne image en utilisant le chemin de l'ancienne image
                        oldImageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
                    );
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                // Enregistrer la nouvelle image dans /images/nom du dossier
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imagesFolder}");
                Directory.CreateDirectory(uploads);

                // Crée un nom de fichier avec un GUID pour éviter les conflits + l'extension du fichier d'origine
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                // Sauvegarde le fichier dans le bon dossier, après l'avoir récupéré via le formulaire utilisateur
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Met à jour l'URL de l'image dans l'entité via le setter 
                setImageUrl(entity, $"/images/{imagesFolder}/{fileName}");
            }
        }

        public static void DeleteImageAsync<T>(
            T entity,
            Func<T, string?> getImageUrl)
            where T : class
        {
            var imageUrl = getImageUrl(entity);

            if (!string.IsNullOrEmpty(imageUrl))
            {
                // Supprimer l'image du dossier
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    imageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
                );
                if (File.Exists(imagePath))
                    File.Delete(imagePath);

            }
        }
    }
}
