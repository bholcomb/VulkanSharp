#include <iostream>

#define EXP __declspec (dllexport)

extern "C"
{
   typedef struct VkShaderModuleCreateInfo {
      int              sType;
      const void*                  pNext;
      int    flags;
      size_t                       codeSize;
      const uint32_t*              pCode;
   } VkShaderModuleCreateInfo;


   int EXP vkCreateShaderModule(int device, VkShaderModuleCreateInfo* pCreateInfo, void* pAllocator, int* pShaderModule)
   {
      std::cout << "type: " << pCreateInfo->sType << std::endl;
      std::cout << "flags: " << pCreateInfo->flags << std::endl;
      std::cout << "codeSize: " << pCreateInfo->codeSize << std::endl;
      std::cout << "pCode: " << pCreateInfo->pCode[0] << ", " << pCreateInfo->pCode[1] << ", " << pCreateInfo->pCode[3] << std::endl;

      *pShaderModule = 3;

      return 0;
   }
}